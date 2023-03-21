namespace iOrderApp.Endpoints.Employees;


public class EmployeeGetAll
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;


    [Authorize(Policy = "Employee065Policy")]
    public static async Task<IResult> Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {

        if (page == null || page == 0)
        {
            return Results.BadRequest("Pages cannot be 0 or null");
        }

        if (rows == null || rows > 10 || rows == 0)
        {
            return Results.BadRequest("Rows Cannot be null or over 10");
        }

        var result = await query.Execute(page.Value, rows.Value);
        return Results.Ok(result);
    }

    

}
