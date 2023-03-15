using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using Dapper;
using iOrderApp.Endpoints.Emloyees;
using iOrderApp.infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace iOrderApp.Endpoints.Employees;


public class EmployeeGetAll
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;


    [Authorize(Policy = "Employee065Policy")]
    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {

        if (page == null || page == 0)
        {
            return Results.BadRequest("Pages cannot be 0 or null");
        }

        if (rows == null || rows > 10 || rows == 0)
        {
            return Results.BadRequest("Rows Cannot be null or over 10");
        }


        return Results.Ok(query.Execute(page.Value, rows.Value));
    }

    

}
