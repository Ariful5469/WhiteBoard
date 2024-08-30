using SignaturePadApp.Data;
using SignaturePadApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace SignaturePadApp.Controllers
{
    public class SignatureController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Use Dependency Injection to inject the ApplicationDbContext
        public SignatureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Signature
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveSignature(string imageData, string userName)
        {
            if (!string.IsNullOrEmpty(imageData))
            {
                // Remove the 'data:image/png;base64,' part from the data URL
                var base64Data = imageData.Split(',')[1];
                byte[] imageBytes = Convert.FromBase64String(base64Data);

                // Save the image data to the database
                var signature = new Signature
                {
                    UserName = userName,
                    ImageData = imageBytes,
                    CreatedAt = DateTime.Now
                };

                _context.Signatures.Add(signature);
                _context.SaveChanges();
            }

            return Json(new { success = true });
        }

        public ActionResult ViewSignatures()
        {
            var signatures = _context.Signatures.ToList(); // Ensure that signatures are retrieved as a list
            return View(signatures);
        }
    }
}
