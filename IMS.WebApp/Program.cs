using IMS.Plugins.InMemory;
using IMS.UseCases.Activities;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.Inventories;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products;
using IMS.UseCases.Products.Interfaces;
using IMS.WebApp.Components;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This container stores all the services that the app can request (inject) later.
// The AddRazorComponents method adds support for Razor Components,
// which are reusable UI components that can be used in Razor Pages or Blazor applications.
// The AddInteractiveServerComponents method configures the components to be interactive
// and rendered on the server.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Configuring Dependency Injection (DI)
// Whenever the app needs an IInventoryRepository, it will create an instance of InventoryRepository and provide it.
// The AddSingleton method means that the same instance of InventoryRepository will be used throughout the app's lifetime.
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IInventoryTransactionRepository, InventoryTransactionRepository>();

builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();
builder.Services.AddTransient<IDeleteInventoryUseCase, DeleteInventoryUseCase>();

builder.Services.AddTransient<IViewProductsByNameUseCase, ViewProductsByNameUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductsByIdUseCase>();

builder.Services.AddTransient<IPurchaseInventoryUseCase, PurchaseInventoryUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

// This line maps the Razor Components to the app,
// allowing us to use them in our pages.
// The AddInteractiveServerRenderMode method specifies that the components
// should be rendered on the server and interact with the client via SignalR.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
