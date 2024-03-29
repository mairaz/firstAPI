using System.Collections.Generic;
using AutoMapper;
using firstAPI.Data;
using firstAPI.Data.Dtos;
using firstAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace firstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<IEnumerable<Filme>> AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {        
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeId), new { id = filme.Id }, filmeDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadFilmeDto>> GetFilmes()
        {
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetFilmeId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null) NotFound();
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateFilme(int id, UpdateFilmeDto filmeDto)
        {            
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme == null) NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id:int}")]
        public IActionResult UpdateFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch){
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id) ;
            if (filme == null) NotFound();
            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

            patch.ApplyTo(filmeParaAtualizar, ModelState);

            if(!TryValidateModel(filmeParaAtualizar)){
                return ValidationProblem(ModelState);
            }
            _mapper.Map(filmeParaAtualizar, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id){
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();

        }
    }
}