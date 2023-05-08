using BlogEngine.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Repository.Interface
{
    public interface IBlogEngineRepository
    {
        IEnumerable<CategoryModel> GetCategories();
        CategoryModel GetCategoryById(int idCategory);
        void InsertCategory(CategoryModel category);
        void UpdateCategory(CategoryModel category);
        void DeleteCategory(int id);
        IEnumerable<PostModel> GetPosts();
        IEnumerable<PostModel> GetPostsPublished();
        PostModel GetPostById(int idPost);
        void InsertPost(PostModel post);
        void UpdatePost(PostModel post);
        void DeletePost(int id);
        IEnumerable<PostModel> GetPostsByIdCategory(int idCategory);
    }
}
