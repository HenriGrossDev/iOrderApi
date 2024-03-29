﻿namespace iOrderApp.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };

    public static Delegate Handle => Action;

    [Authorize]
    public static IResult Action([FromRoute]Guid id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        context.Categories.Remove(category);
        context.SaveChanges();


        return Results.Ok("Category deleted.");
    }

}
