using CharityWork.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ImageController : ControllerBase {
		string rootPath = "E:\\Anguler\\final project\\Charitywork\\src\\assets\\Images";
		[Route("upload")]
		[HttpPost]
		public async Task<IActionResult> UploadImage() {
			try {
				var file = Request.Form.Files[0];
				var ext = Path.GetExtension(file.FileName);
				var fileName = Guid.NewGuid().ToString() + ext;
				var fullPath = Path.Combine(rootPath, fileName);
				using (var stream = new FileStream(fullPath, FileMode.Create)) {
					await file.CopyToAsync(stream);
				}
				return Ok(fileName);
			}
			catch (Exception ex) {
				return Problem(ex.Message);
			}
		}
		[Route("update")]
		[HttpPost]
		public async Task<IActionResult> updateImage(string imagePath) {
			try {
				var file = Request.Form.Files[0];
				var fullPath = Path.Combine(rootPath, imagePath);
				using (var stream = new FileStream(fullPath, FileMode.Create)) {
					await file.CopyToAsync(stream);
				}
				return Ok();
			}
			catch (Exception ex) {
				return Problem(ex.Message);
			}
		}
	}
}
