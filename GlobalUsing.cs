﻿global using AutoMapper;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Newtonsoft.Json;
global using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
global using OnlineMarket.AutoMapper;
global using OnlineMarket.Data;
global using OnlineMarket.Enums;
global using OnlineMarket.Helper;
global using OnlineMarket.Interfaces.Models;
global using OnlineMarket.Interfaces.Person;
global using OnlineMarket.Interfaces.Repasitories.Generic;
global using OnlineMarket.Interfaces.Repasitories.Services;
global using OnlineMarket.Interfaces.UnitOfWork;
global using OnlineMarket.Models.Dtos.Cart;
global using OnlineMarket.Models.Dtos.CartItem;
global using OnlineMarket.Models.Dtos.Category;
global using OnlineMarket.Models.Dtos.Customer;
global using OnlineMarket.Models.Dtos.Discount;
global using OnlineMarket.Models.Dtos.Employee;
global using OnlineMarket.Models.Dtos.Notification;
global using OnlineMarket.Models.Dtos.Order;
global using OnlineMarket.Models.Dtos.OrderItem;
global using OnlineMarket.Models.Dtos.Payment;
global using OnlineMarket.Models.Dtos.Product;
global using OnlineMarket.Models.Dtos.ProductCategory;
global using OnlineMarket.Models.Dtos.Review;
global using OnlineMarket.Models.Dtos.ShippingInfo;
global using OnlineMarket.Models.Dtos.User;
global using OnlineMarket.Models.Models;
global using OnlineMarket.Models.Other;
global using OnlineMarket.Repositories.Generic;
global using OnlineMarket.Repositories.Service;
global using OnlineMarket.UnitOfWorks;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.Linq.Expressions;
