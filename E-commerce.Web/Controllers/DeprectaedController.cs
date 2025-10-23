//using Microsoft.AspNetCore.Mvc;

//namespace E_commerce.Web.Controllers;
//[ApiController]
//[Route("api/[Controller]")]
//public class ProductsController : ControllerBase
//{
//    [HttpGet("{id}")]
//    public ActionResult Get(int id)
//    {
//        return Ok(new Product { Id = id });
//    }
//    [HttpGet]
//    public ActionResult GetAll()
//    {
//        return Ok(new Product { });
//    }

//    [HttpPost]
//    public ActionResult Create(Product product)
//    {
//        return Created("Test", product);
//    }
//    [HttpPut]
//    public ActionResult Update(Product product)
//    {
//        return Ok(product);
//    }
//    [HttpDelete]
//    public ActionResult Delete(int id)
//    {
//        return NoContent();
//    }
//}

//public class Product
//{
//    public int Id { get; set; }
//    public string Name { get; set; } = "Product";
//    public string Description { get; set; }
//    public decimal Price { get; set; }
//}
