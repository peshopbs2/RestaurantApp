using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data.Data;
using RestaurantApp.Data.Entities;
using RestaurantApp.Services;
using RestaurantApp.Services.Abstractions;
using RestaurantApp.Services.DTOs;
using RestaurantApp.Web.Models;
using RestaurantApp.Web.Utils;

namespace RestaurantApp.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

        public RestaurantsController(IRestaurantService restaurantService, ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _restaurantService = restaurantService;
            _categoryService = categoryService;
            _environment = environment;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            return View(await _restaurantService.GetRestaurantsAsync());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id.Value);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetCategoriesAsync();
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RestaurantCreateEditViewModel restaurant)
        {
            if (ModelState.IsValid)
            {
                if (restaurant.Picture != null && restaurant.Picture.Length > 0)
                {
                    var newFileName = await FileUpload.UploadAsync(restaurant.Picture, _environment.WebRootPath);
                    restaurant.PictureUrl = newFileName;
                }

                await _restaurantService.AddRestaurantAsync(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _restaurantService
                .GetRestaurantByIdEditAsync(id.Value);
            if (restaurant == null)
            {
                return NotFound();
            }
            ViewBag.Categories = await _categoryService.GetCategoriesAsync();
            return View(new RestaurantCreateEditViewModel()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Address = restaurant.Address,
                PictureUrl = restaurant.PictureUrl,
                Website = restaurant.Website,
                Phone = restaurant.Phone,
                CategoriesIds = restaurant.CategoriesIds
            });
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RestaurantCreateEditViewModel restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (restaurant.Picture != null && restaurant.Picture.Length > 0)
                {
                    var newFileName = await FileUpload.UploadAsync(restaurant.Picture, _environment.WebRootPath);
                    restaurant.PictureUrl = newFileName;
                }

                try
                {
                    await _restaurantService.UpdateRestaurantAsync(restaurant);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await RestaurantExists(restaurant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id.Value);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _restaurantService.DeleteRestaurantByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RestaurantExists(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            return restaurant != null;
        }
    }
}
