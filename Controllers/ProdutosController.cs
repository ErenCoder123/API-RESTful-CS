using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _repository;

    public ProdutosController(IProdutoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<List<Produto>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> GetById(int id)
    {
         var produtoEncontrado = _repository.GetById(id);

        if(produtoEncontrado == null)
            return NotFound();

        return produtoEncontrado;
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        _repository.Post(produto);
        return Created();
    }
    
    [HttpPut("{id}")]
    public ActionResult Put(int id, Produto produtoAtualizado)
    {
        var produtoEncontrado = _repository.Put(id, produtoAtualizado);
        
        if(produtoEncontrado == null)
            return NotFound();
        
        return Ok(produtoEncontrado);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var produtoEncontrado = _repository.Delete(id);
        
        if(produtoEncontrado == null)
            return NotFound();
        
        return NoContent();
    }
}