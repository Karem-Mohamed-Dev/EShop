﻿namespace EShop.Abstractions.Consts;

public static class Permissions
{
    public static string Type { get; } = "Permissions";

    public const string AddProduct = "product:add";
    public const string UpdateProduct = "product:update";
    public const string DeleteProduct = "product:delete";


    public const string AddReview = "review:add";
    public const string UpdateReview = "review:update";
    public const string DeleteReview = "review:delete";


    public const string GetUsers = "users:read";
    public const string AddUsers = "users:add";
    public const string UpdateUsers = "users:update";


    public const string GetRoles = "roles:read";
    public const string AddRoles = "roles:add";
    public const string UpdateRoles = "roles:update";
    public const string ToggleRoleStatus = "roles:togglestatus";


    public const string AddCategory = "categories:add";
    public const string UpdateCategory = "categories:update";
    public const string ToggleCategoryStatus = "categories:togglestatus";
    
    public const string AddSubCategory = "subcategories:add";
    public const string UpdateSubCategory = "subcategories:update";
    public const string ToggleSubCategoryStatus = "subcategories:togglestatus";

    public static IList<string?> GetAllPermissions() => 
        typeof(Permissions).GetFields().Select(x => x.GetValue(x) as string).ToList();
}
