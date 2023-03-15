﻿using iOrderApp.Domain.Products;
using iOrderApp.infra.Data;
using iOrderApp.Endpoints.Categories;
using Microsoft.AspNetCore.Authorization;

namespace iOrderApp.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    [Authorize]
    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(c => new CategoryResponse {Id = c.Id, Name = c.Name, Active = c.Active });

        return Results.Ok(response);
    }

}
