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

namespace RestaurantApp.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ICategoryService _categoryService;

        public RestaurantsController(IRestaurantService restaurantService, ICategoryService categoryService)
        {
            _restaurantService = restaurantService;
            _categoryService = categoryService;
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
        public async Task<IActionResult> Create(RestaurantDTO restaurant)
        {
            if (ModelState.IsValid)
            {
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

            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id.Value);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Address,PictureUrl,Phone,Website,Id")] RestaurantDTO restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
