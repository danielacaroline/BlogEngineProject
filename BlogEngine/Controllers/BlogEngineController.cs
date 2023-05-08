using BlogEngine.Models;
using BlogEngine.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Data.SqlClient;
using System.Data;

namespace BlogEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogEngineController : ControllerBase
    {

        private readonly IBlogEngineRepository _blogEngineRepository;

        public BlogEngineController(IBlogEngineRepository blogEngineRepository)
        {
            _blogEngineRepository = blogEngineRepository;
        }

        [HttpGet("categories")]
        public JsonResult GetCategories()
        {
            try
            {
                IEnumerable<CategoryModel> categories = _blogEngineRepository.GetCategories();
                if (categories.Any())
                {
                    return new JsonResult(categories)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                return new JsonResult("No Content")
                {
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            };
        }

        [HttpGet("categories/{id}")]
        public JsonResult GetCategoryById(int id)
        {
            try
            {
                CategoryModel category = _blogEngineRepository.GetCategoryById(id);

                if (!string.IsNullOrWhiteSpace(category.Title))
                {
                    return new JsonResult(category)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                return new JsonResult("No Content")
                {
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            };
        }

        [HttpPost("categories")]
        public JsonResult PostCategory(CategoryModel category)
        {
            try
            {
                _blogEngineRepository.InsertCategory(category);

                return new JsonResult("Created Successfully")
                {
                    StatusCode = StatusCodes.Status201Created
                };

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPut("categories")]
        public JsonResult UpdateCategory(CategoryModel category)
        {
            try
            {
                _blogEngineRepository.UpdateCategory(category);
                return new JsonResult("Updated Successfully")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpDelete("categories/{id}")]
        public JsonResult DeleteCategory(int id)
        {
            try
            {
                _blogEngineRepository.DeleteCategory(id);
                return new JsonResult("Deleted Successfully")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("REFERENCE constraint") && ex.Message.Contains("FK_category_post"))
                {
                    return new JsonResult(ex.Message)
                    {
                        StatusCode = StatusCodes.Status406NotAcceptable
                    };
                }
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpGet("posts")]
        public JsonResult GetPostsPublished()
        {
            try
            {
                IEnumerable<PostModel> posts = _blogEngineRepository.GetPostsPublished();
                if (posts.Any())
                {
                    return new JsonResult(posts)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                return new JsonResult("No Content")
                {
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpGet("all-posts")]
        public JsonResult GetAllPosts()
        {
            try
            {
                IEnumerable<PostModel> posts = _blogEngineRepository.GetPosts();

                if (posts.Any())
                {
                    return new JsonResult(posts)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                return new JsonResult("No Content")
                {
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpGet("posts/{id}")]
        public JsonResult GetPostById(int id)
        {
            try
            {
                PostModel post = _blogEngineRepository.GetPostById(id);
                if (!string.IsNullOrWhiteSpace(post.Title))
                {
                    return new JsonResult(post)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                return new JsonResult("No Content")
                {
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPost("posts")]
        public JsonResult PostContent(PostModel post)
        {
            try
            {
                _blogEngineRepository.InsertPost(post);
                return new JsonResult("Created Successfully")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPut("posts")]
        public JsonResult UpdatePost(PostModel post)
        {
            try
            {
                _blogEngineRepository.UpdatePost(post);
                return new JsonResult("Updated Successfully")
                {
                    StatusCode = StatusCodes.Status200OK
                }; ;
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpDelete("posts/{id}")]
        public JsonResult DeletePost(int id)
        {
            try
            {
                _blogEngineRepository.DeletePost(id);
                return new JsonResult("Deleted Successfully")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }


        [HttpGet("categories/{id}/posts")]
        public JsonResult GetPostsByIdCategory(int id)
        {
            try
            {
                IEnumerable<PostModel> posts = _blogEngineRepository.GetPostsByIdCategory(id);
                return new JsonResult(posts)
                {
                    StatusCode = StatusCodes.Status200OK
                }; ;
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
