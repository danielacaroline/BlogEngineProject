namespace BlogEngine.Repository.Script
{
    public static class SqlScript
    {
        public const string GetCategories = @"
                     SELECT  +
                       c.category_id
                       ,c.title 
                    FROM category c";

        public const string GetCategoryById = @" 
                   SELECT 
                       c.category_id
                       ,c.title
                   FROM 
                       category c
                   WHERE
                       c.category_id = @category_id";

        public const string InsertCategory = @" 
                   INSERT INTO category
                   VALUES 
                       (@title)" ;

        public const string UpdateCategory = @" 
                   UPDATE category 
                   SET
                        title = @title
                    WHERE
                       category_id = @category_id";

        public const string DeleteCategory = @"
                   DELETE FROM category 
                   WHERE
                      category_id = @category_id";

        public const string GetPosts = @" 
                    SELECT
                       p.post_id
                       ,p.title
                       ,p.publication_date 
                       ,p.content_post
                      ,p.category_id
                    FROM 
                       post p
                    ORDER BY p.publication_date DESC";

        public const string GetPostsPublished = @" 
                    SELECT
                       p.post_id
                       ,p.title
                       ,p.publication_date 
                       ,p.content_post
                       ,p.category_id 
                    FROM
                        post p
                    WHERE 
                        p.publication_date <= getdate()
                    ORDER BY p.publication_date DESC";

        public const string GetPostById = @" 
                    SELECT
                       p.post_id 
                       ,p.title 
                       ,p.publication_date 
                       ,p.content_post
                       ,p.category_id 
                    FROM 
                        post p
                    WHERE
                         p.post_id = @post_id";

        public const string InsertPost = @" 
                   INSERT INTO post
                   VALUES 
                       (@title, @publication_date, @content_post, @category_id)";

        public const string UpdatePost= @" 
                   UPDATE post
                    SET
                        title = @title
                        ,publication_date =  @publication_date
                        ,content_post = @content_post
                        ,category_id = @category_id
                    WHERE
                        post_id = @post_id";

        public const string DeletePost = @" 
                   DELETE FROM post 
                   WHERE
                        post_id = @post_id";

        public const string GetPostsByCategory = @" 
                     SELECT
                       p.post_id 
                       ,p.title
                       ,p.publication_date 
                       ,p.content_post
                       ,p.category_id
                    FROM 
                        post p
                    WHERE
                        p.category_id = @category_id
                        AND p.publication_date <= getdate()
                        ORDER BY p.publication_date DESC";

    }
}
