﻿global using System.Reflection;
global using System.Text;

global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using Mapster;

global using FluentValidation;
global using FluentValidation.AspNetCore;

global using EShop.Abstractions;
global using EShop.Abstractions.Consts;
global using EShop.Authentication;
global using EShop.Authentication.Filters;
global using EShop.Contracts.Auth;
global using EShop.Entities;
global using EShop.Errors;
global using EShop.Persistence;
global using EShop.Services;
global using EShop.Contracts.Role;
global using EShop.Contracts.Category;
global using EShop.Contracts.SubCategory;
global using EShop.Contracts.Product;