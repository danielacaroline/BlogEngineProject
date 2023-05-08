using BlogEngine.Controllers;
using BlogEngine.Models;
using BlogEngine.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Test
{
    public class BlogEngineControllerTestes
    {
        private readonly Mock<IBlogEngineRepository> _blogEngineRespositoryMock = new();

        //categories
        [Fact]
        public void GetCategories_HappyPath()
        {
            List<CategoryModel> categories = new();
            categories.Add(
                new CategoryModel
                {
                    Id = 1,
                    Title = "Category1"
                });

            categories.Add(
               new CategoryModel
               {
                   Id = 2,
                   Title = "Category2"
               });

            _blogEngineRespositoryMock.Setup(repository => repository.GetCategories()).Returns(categories);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetCategories();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, result.StatusCode);
            var model = Assert.IsAssignableFrom<IEnumerable<CategoryModel>>(result.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void GetCategories_NoContent()
        {
            List<CategoryModel> categories = new();

            _blogEngineRespositoryMock.Setup(repository => repository.GetCategories()).Returns(categories);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetCategories();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(204, result.StatusCode);
            Assert.Equal("No Content", result.Value);
        }

        [Fact]
        public void GetCategories_Exception()
        {

            _blogEngineRespositoryMock.Setup(repository => repository.GetCategories()).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetCategories();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }

        [Fact]
        public void GetCategoryById_HappyPath()
        {
            CategoryModel category = new()
            {
                Id = 1,
                Title = "Category1"
            };

            _blogEngineRespositoryMock.Setup(repository => repository.GetCategoryById(category.Id)).Returns(category);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetCategoryById(category.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, result.StatusCode);
            var model = Assert.IsAssignableFrom<CategoryModel>(result.Value);
            Assert.Equal(1, model.Id);
            Assert.Equal("Category1", model.Title);
        }


        [Fact]
        public void GetCategoryById_NoContent()
        {
            CategoryModel category = new()
            {
                Id = 1,
                Title = "Category1"
            };

            CategoryModel category_empt = new();

            _blogEngineRespositoryMock.Setup(repository => repository.GetCategoryById(category.Id)).Returns(category_empt);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetCategoryById(category.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(204, result.StatusCode);
            Assert.Equal("No Content", result.Value);
        }

        [Fact]
        public void GetCategoryById_Exception()
        {
            CategoryModel category = new()
            {
                Id = 1,
                Title = "Category1"
            };

            _blogEngineRespositoryMock.Setup(repository => repository.GetCategoryById(category.Id)).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetCategoryById(category.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }


        [Fact]
        public void PostCategories_HappyPath()
        {
            CategoryModel category = new()
            {
                Id = 1,
                Title = "Category1"
            };

            _blogEngineRespositoryMock.Setup(repository => repository.InsertCategory(category));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.PostCategory(category);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal("Created Successfully", result.Value);
        }

        [Fact]
        public void PostCategory_Exception()
        {
            CategoryModel category = new()
            {
                Id = 1,
                Title = "Category1"
            };

            _blogEngineRespositoryMock.Setup(b=>b.InsertCategory(category)).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.PostCategory(category);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }
        [Fact]
        public void PutCategories_HappyPath()
        {
            CategoryModel category = new()
            {
                Id = 1,
                Title = "Category1"
            };

            _blogEngineRespositoryMock.Setup(repository => repository.UpdateCategory(category));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.UpdateCategory(category);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Updated Successfully", result.Value);
        }

        [Fact]
        public void PutCategory_Exception()
        {
            CategoryModel category = new()
            {
                Id = 1,
                Title = "Category1"
            };

            _blogEngineRespositoryMock.Setup(b => b.UpdateCategory(category)).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.UpdateCategory(category);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }
        [Fact]
        public void DeleteCategories_HappyPath()
        {
            CategoryModel category = new()
            {
                Id = 1,
                Title = "Category1"
            };

            _blogEngineRespositoryMock.Setup(repository => repository.DeleteCategory(category.Id));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.DeleteCategory(category.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Deleted Successfully", result.Value);
        }

        [Fact]
        public void DeleteCategories_Exception()
        {
            CategoryModel category = new()
            {
                Id = 1,
                Title = "Category1"
            };

            _blogEngineRespositoryMock.Setup(repository => repository.DeleteCategory(category.Id)).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.DeleteCategory(category.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }

        //posts
        [Fact]
        public void GetAllPosts_HappyPath()
        {
            List<PostModel> posts = new();
            posts.Add(
                new PostModel
                {
                    Id = 1,
                    Title = "Title 1",
                    PublicationDate = new DateTime(2023,2,1),
                    Content = "Content post test 1",
                    IdCategory = 1
                });

            posts.Add(
               new PostModel
               {
                   Id = 1,
                   Title = "Title 1",
                   PublicationDate = new DateTime(2023, 5, 10),
                   Content = "Content post test 2",
                   IdCategory = 2
               });

            posts.Add(
              new PostModel
              {
                  Id = 1,
                  Title = "Title 1",
                  PublicationDate = new DateTime(2021, 12,30),
                  Content = "Content post test 3",
                  IdCategory = 2
              });


            _blogEngineRespositoryMock.Setup(repository => repository.GetPosts()).Returns(posts);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetAllPosts();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, result.StatusCode);
            var model = Assert.IsAssignableFrom<IEnumerable<PostModel>>(result.Value);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void GetAllPosts_NoContent()
        {
            List<PostModel> posts = new();

            _blogEngineRespositoryMock.Setup(repository => repository.GetPosts()).Returns(posts);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetAllPosts();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(204, result.StatusCode);
            Assert.Equal("No Content", result.Value);
        }

        [Fact]
        public void GetAllPosts_Exception()
        {

            _blogEngineRespositoryMock.Setup(repository => repository.GetPosts()).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetAllPosts();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }

        [Fact]
        public void GetPosts_HappyPath()
        {
            List<PostModel> posts = new();
            posts.Add(
                new PostModel
                {
                    Id = 1,
                    Title = "Title 1",
                    PublicationDate = new DateTime(2023, 2, 1),
                    Content = "Content post test 1",
                    IdCategory = 1
                });

            posts.Add(
               new PostModel
               {
                   Id = 1,
                   Title = "Title 1",
                   PublicationDate = new DateTime(2023, 5, 10),
                   Content = "Content post test 2",
                   IdCategory = 2
               });

            posts.Add(
              new PostModel
              {
                  Id = 1,
                  Title = "Title 1",
                  PublicationDate = new DateTime(2021, 12, 30),
                  Content = "Content post test 3",
                  IdCategory = 2
              });


            _blogEngineRespositoryMock.Setup(repository => repository.GetPostsPublished()).Returns(posts);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetPostsPublished();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, result.StatusCode);
            var model = Assert.IsAssignableFrom<IEnumerable<PostModel>>(result.Value);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void GetPosts_NoContent()
        {
            List<PostModel> posts = new();

            _blogEngineRespositoryMock.Setup(repository => repository.GetPostsPublished()).Returns(posts);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetPostsPublished();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(204, result.StatusCode);
            Assert.Equal("No Content", result.Value);
        }

        [Fact]
        public void GetPosts_Exception()
        {
            _blogEngineRespositoryMock.Setup(repository => repository.GetPostsPublished()).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetPostsPublished();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }

        [Fact]
        public void GetPostById_HappyPath()
        {
            PostModel post = new ()
            {
                Id = 1,
                Title = "Title 1",
                PublicationDate = new DateTime(2021, 12, 30),
                Content = "Content post test 3",
                IdCategory = 2
            };

            _blogEngineRespositoryMock.Setup(repository => repository.GetPostById(post.Id)).Returns(post);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetPostById(post.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, result.StatusCode);
            var model = Assert.IsAssignableFrom<PostModel>(result.Value);
            Assert.Equal(1, model.Id);
            Assert.Equal("Title 1", model.Title);
        }


        [Fact]
        public void GetPostById_NoContent()
        {
            PostModel post = new ()
            {
                Id = 1,
                Title = "Title 1",
                PublicationDate = new DateTime(2021, 12, 30),
                Content = "Content post test 3",
                IdCategory = 2
            };

            PostModel post_empt = new();

            _blogEngineRespositoryMock.Setup(repository => repository.GetPostById(post.Id)).Returns(post_empt);
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetPostById(post.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(204, result.StatusCode);
            Assert.Equal("No Content", result.Value);
        }

        [Fact]
        public void GetPostById_Exception()
        {
            PostModel post = new ()
            {
                Id = 1,
                Title = "Title 1",
                PublicationDate = new DateTime(2021, 12, 30),
                Content = "Content post test 3",
                IdCategory = 2
            };

            _blogEngineRespositoryMock.Setup(repository => repository.GetPostById(post.Id)).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.GetPostById(post.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }


        [Fact]
        public void InsertPost_HappyPath()
        {
            PostModel post = new ()
            {
                Id = 1,
                Title = "Title 1",
                PublicationDate = new DateTime(2021, 12, 30),
                Content = "Content post test 3",
                IdCategory = 2
            };

            _blogEngineRespositoryMock.Setup(repository => repository.InsertPost(post));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.PostContent(post);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal("Created Successfully", result.Value);
        }

        [Fact]
        public void InsertPost_Exception()
        {
            PostModel post = new()
            {
                Id = 1,
                Title = "Title 1",
                PublicationDate = new DateTime(2021, 12, 30),
                Content = "Content post test 3",
                IdCategory = 2
            };

            _blogEngineRespositoryMock.Setup(b => b.InsertPost(post)).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.PostContent(post);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }
        [Fact]
        public void PutPost_HappyPath()
        {
            PostModel post = new()
            {
                Id = 1,
                Title = "Title 1",
                PublicationDate = new DateTime(2021, 12, 30),
                Content = "Content post test 3",
                IdCategory = 2
            };

            _blogEngineRespositoryMock.Setup(repository => repository.UpdatePost(post));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.UpdatePost(post);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Updated Successfully", result.Value);
        }

        [Fact]
        public void PutPost_Exception()
        {
            PostModel post = new()
            {
                Id = 1,
                Title = "Title 1",
                PublicationDate = new DateTime(2021, 12, 30),
                Content = "Content post test 3",
                IdCategory = 2
            };

            _blogEngineRespositoryMock.Setup(b => b.UpdatePost(post)).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.UpdatePost(post);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }
        [Fact]
        public void DeletePost_HappyPath()
        {
            PostModel post = new()
            {
                Id = 1,
                Title = "Title 1",
                PublicationDate = new DateTime(2021, 12, 30),
                Content = "Content post test 3",
                IdCategory = 2
            };

            _blogEngineRespositoryMock.Setup(repository => repository.DeletePost(post.Id));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.DeletePost(post.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Deleted Successfully", result.Value);
        }

        [Fact]
        public void DeletePost_Exception()
        {
            PostModel post = new()
            {
                Id = 1,
                Title = "Title 1",
                PublicationDate = new DateTime(2021, 12, 30),
                Content = "Content post test 3",
                IdCategory = 2
            };

            _blogEngineRespositoryMock.Setup(b => b.DeletePost(post.Id)).Throws(new Exception("exception"));
            var blogEngineController = new BlogEngineController(_blogEngineRespositoryMock.Object);

            var result = blogEngineController.DeletePost(post.Id);

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("exception", result.Value);
        }
    }
}