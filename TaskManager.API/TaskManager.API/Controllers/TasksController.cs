using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }


        /// <summary>
        /// Busca uma tarefa pelo Id
        /// </summary>
        /// <response code="200">Tarefa encontrada</response>
        /// <response code="404">Tarefa não encontrada</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        /// <summary>
        /// Cria uma nova tarefa
        /// </summary>
        /// <response code="201">Tarefa criada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskDto dto)
        {
            var id = await _service.CreateAsync(dto.Title, dto.Description);

            var task = await _service.GetByIdAsync(id);

            return CreatedAtAction(nameof(GetById), new { id }, task);
        }

        /// <summary>
        /// Atualiza uma tarefa existente
        /// </summary>
        /// <response code="204">Tarefa atualizada com sucesso</response>
        /// <response code="404">Tarefa não encontrada</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskDto dto) 
        {
            var success = await _service.UpdateAsync(id, dto.Title, dto.Description, dto.Status);

            if(!success)
                return NotFound("Task nao encontrada");

            return NoContent();
        
        }

        /// <summary>
        /// Remove uma tarefa
        /// </summary>
        /// <response code="204">Tarefa removida com sucesso</response>
        /// <response code="404">Tarefa não encontrada</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if(!success)
                return NotFound("Task nao encontrada");

            return NoContent();
        }

        [HttpDelete("all")]
        public async Task<IActionResult> DeleteAll()
        {
            await _service.DeleteAllAsync();
            return NoContent();
        }
    }
}
