
//namespace OnlineMarket
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddControllers();

//            // Configure PostgreSQL database connection
//            var connectionString = Configuration.GetConnectionString("DefaultConnection");
//            services.AddDbContext<OnlineMarketDB>(options =>
//                options.UseNpgsql(connectionString));

//            // Add services
//            services.AddScoped<ICartService, CartService>();
//            services.AddScoped<ICartItemService, CartItemService>();
//            services.AddScoped<ICategoryService, CategoryService>();
//            services.AddScoped<ICustomerService, CustomerService>();
//            services.AddScoped<IDiscountService, DiscountService>();
//            services.AddScoped<IEmployeeService, EmployeeService>();
//            services.AddScoped<INotificationService, NotificationService>();
//            services.AddScoped<IOrderItemService, OrderItemService>();
//            services.AddScoped<IOrderService, OrderService>();
//            services.AddScoped<IPaymentService, PaymentService>();
//            services.AddScoped<IProductCategoryService, ProductCategoryService>();
//            services.AddScoped<IProductService, ProductService>();
//            services.AddScoped<IReviewService, ReviewService>();
//            services.AddScoped<IShippingInfoService, ShippingInfoService>();

            
//            // Add other services

//            // Configure authentication and JWT
//            services.AddAuthentication(options =>
//            {
//                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            })
//            .AddJwtBearer(options =>
//            {
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidateIssuerSigningKey = true,
//                    ValidIssuer = "your-issuer",
//                    ValidAudience = "your-audience",
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"))
//                };
//            });

//            services.AddSwaggerGen(); // For API documentation

//            // Add other configurations, authentication, etc.
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseSwagger();
//                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1"));
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthentication(); // Use authentication
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }

//        private string GenerateJwtToken(User user)
//        {
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                issuer: "your-issuer",
//                audience: "your-audience",
//                claims: new List<Claim>(),
//                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
//                signingCredentials: creds
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        public void CustomExpectionHandlerMiddleware(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            // ... Other middleware configurations

//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//            }

//            app.UseMiddleware<CustomExceptionHandlerMiddleware>(); // Use the custom exception handler middleware

//            // ... Other middleware configurations
//        }

//    }
//}
