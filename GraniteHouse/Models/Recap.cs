using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Models
{
    public class Recap
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        /*
         * if (!ModelState.IsValid)
            {
                return View(ProductsVM);
            }

            _db.Products.Add(ProductsVM.Products);
            await _db.SaveChangesAsync();

            //Save Products into an object
            var productsFromDb = _db.Products.Find(ProductsVM.Products.Id);
            //Save Images
            // Create a path for the images located in : wwwroot
            string webRootPath = _hostingEnvironment.WebRootPath;

            //HTTP Request to retrieve images
            var files = HttpContext.Request.Form.Files;

            // Check if image has been uploaded
            if (files.Count != 0)
            {
                // Success, locate the path to the exact location
                //webRootPath = wwwroot, Utility.StaticDetails.ImageFolder = images/ProductImages
                var uploads = Path.Combine(webRootPath, Utility.StaticDetails.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(ProductsVM.Products.Id + extension)
                      , FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                // Define the exact image saving location on the server
                productsFromDb.Image = @"\" + StaticDetails.ImageFolder
                                     + @"\" + ProductsVM.Products.Id + extension;
            }
            else
            {
                // User did not upload an image
                // Create upload path for the default_image
                var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolder
                            + @"\" + StaticDetails.DefaultProductImage);
                // Set default_image as the ProductID - Define the Path to the Default_image
                System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.ImageFolder
                                    + @"\" + ProductsVM.Products.Id + ".png");
                // Upload the default_image
                productsFromDb.Image = @"\" + StaticDetails.ImageFolder
                                    + @"\" + ProductsVM.Products.Id + ".png";
            }
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            */
    }
}
