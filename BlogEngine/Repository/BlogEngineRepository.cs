using BlogEngine.Models;
using BlogEngine.Repository.Interface;
using BlogEngine.Repository.Script;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BlogEngine.Repository
{
    public class BlogEngineRepository : IBlogEngineRepository
    {
        private readonly IConfiguration _configuration;
        public BlogEngineRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("BlogEngineConnection");
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            List<CategoryModel> categories = new();
            using (SqlConnection sqlConnection = new (GetConnectionString()))
            {
                SqlCommand cmd = new()
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = SqlScript.GetCategories
                };

                cmd.Parameters.Clear();

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new CategoryModel()
                    {
                        Id = reader.GetInt32("category_id"),
                        Title = reader.GetString("title")
                    });
                }
                sqlConnection.Close();
            }

            return categories;
        }

        public CategoryModel GetCategoryById(int idCategory)
        {
            CategoryModel category = new();
            using (SqlConnection sqlConnection = new(GetConnectionString()))
            {
                SqlCommand cmd = new()
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = SqlScript.GetCategoryById
                };
                cmd.Parameters.Add("category_id", SqlDbType.Int).Value = idCategory;

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    category = new CategoryModel()
                    {
                        Id = reader.GetInt32("category_id"),
                        Title = reader.GetString("title")
                    };
                }
                sqlConnection.Close();
            }

           
            return category;
        }

        public void InsertCategory(CategoryModel category)
        {
            using SqlConnection sqlConnection = new(GetConnectionString());
            SqlCommand cmd = new()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = SqlScript.InsertCategory
            };
            cmd.Parameters.Add("title", SqlDbType.VarChar).Value = category.Title;

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            sqlConnection.Close();
        }

        public void UpdateCategory(CategoryModel category)
        {
            using SqlConnection sqlConnection = new(GetConnectionString());
            SqlCommand cmd = new()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = SqlScript.UpdateCategory
            };
            cmd.Parameters.Add("category_id", SqlDbType.Int).Value = category.Id;
            cmd.Parameters.Add("title", SqlDbType.VarChar).Value = category.Title;

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            sqlConnection.Close();
        }

        public void DeleteCategory(int id)
        {
            using SqlConnection sqlConnection = new(GetConnectionString());
            SqlCommand cmd = new()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = SqlScript.DeleteCategory
            };
            cmd.Parameters.Add("category_id", SqlDbType.Int).Value = id;

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            sqlConnection.Close();
        }

        public IEnumerable<PostModel> GetPosts()
        {
            List<PostModel> posts = new ();
            using (SqlConnection sqlConnection = new(GetConnectionString()))
            {
                SqlCommand cmd = new()
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = SqlScript.GetPosts
                };
                cmd.Parameters.Clear();

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    posts.Add(new PostModel()
                    {
                        Id = reader.GetInt32("post_id"),
                        Title = reader.GetString("title"),
                        PublicationDate = reader.GetDateTime("publication_date"),
                        Content = reader.GetString("content_post"),
                        IdCategory = reader.GetInt32("category_id")
                    });
                }
            }

            return posts;
        }

        public IEnumerable<PostModel> GetPostsPublished()
        {
            List<PostModel> posts = new();
            using (SqlConnection sqlConnection = new(GetConnectionString()))
            {
                SqlCommand cmd = new()
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = SqlScript.GetPostsPublished
                };
                cmd.Parameters.Clear();

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    posts.Add(new PostModel()
                    {
                        Id = reader.GetInt32("post_id"),
                        Title = reader.GetString("title"),
                        PublicationDate = reader.GetDateTime("publication_date"),
                        Content = reader.GetString("content_post"),
                        IdCategory = reader.GetInt32("category_id")
                    });
                }
            }

            return posts;
        }

        public PostModel GetPostById(int idPost)
        {
            PostModel post = new();
            using (SqlConnection sqlConnection = new(GetConnectionString()))
            {
                SqlCommand cmd = new()
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = SqlScript.GetPostById
                };
                cmd.Parameters.Add("post_id", SqlDbType.Int).Value = idPost;

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    post = new PostModel()
                    {
                        Id = reader.GetInt32("post_id"),
                        Title = reader.GetString("title"),
                        PublicationDate = reader.GetDateTime("publication_date"),
                        Content = reader.GetString("content_post"),
                        IdCategory = reader.GetInt32("category_id")
                    };
                }
                sqlConnection.Close();
            };

            return post;
        }

        public void InsertPost(PostModel post)
        {
            using SqlConnection sqlConnection = new(GetConnectionString());
            SqlCommand cmd = new()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = SqlScript.InsertPost
            };

            cmd.Parameters.Add("title", SqlDbType.VarChar).Value = post.Title;
            cmd.Parameters.Add("publication_date", SqlDbType.DateTime).Value = post.PublicationDate;
            cmd.Parameters.Add("content_post", SqlDbType.Text).Value = post.Content;
            cmd.Parameters.Add("category_id", SqlDbType.Int).Value = post.IdCategory;

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            sqlConnection.Close();
        }

        public void UpdatePost(PostModel post)
        {
            using SqlConnection sqlConnection = new(GetConnectionString());
            SqlCommand cmd = new()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = SqlScript.UpdatePost
            };
            cmd.Parameters.Add("post_id", SqlDbType.Int).Value = post.Id;
            cmd.Parameters.Add("title", SqlDbType.VarChar).Value = post.Title;
            cmd.Parameters.Add("publication_date", SqlDbType.DateTime).Value = post.PublicationDate;
            cmd.Parameters.Add("content_post", SqlDbType.Text).Value = post.Content;
            cmd.Parameters.Add("category_id", SqlDbType.Int).Value = post.IdCategory;

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            sqlConnection.Close();
        }

        public void DeletePost(int id)
        {
            using SqlConnection sqlConnection = new(GetConnectionString());
            SqlCommand cmd = new()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = SqlScript.DeletePost
            };
            cmd.Parameters.Add("post_id", SqlDbType.Int).Value = id;

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            sqlConnection.Close();
        }


        public IEnumerable<PostModel> GetPostsByIdCategory(int idCategory)
        {
            List<PostModel> posts = new();
            using (SqlConnection sqlConnection = new (GetConnectionString()))
            {
                SqlCommand cmd = new()
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = SqlScript.GetPostsByCategory
                };

                cmd.Parameters.Add("category_id", SqlDbType.Int).Value = idCategory;

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    posts.Add(new PostModel()
                    {
                        Id = reader.GetInt32("post_id"),
                        Title = reader.GetString("title"),
                        PublicationDate = reader.GetDateTime("publication_date"),
                        Content = reader.GetString("content_post"),
                        IdCategory = reader.GetInt32("category_id")
                    });
                }
            }
           
            return posts;
        }
    }
}
