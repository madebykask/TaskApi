using System.Web.Mvc;
using TaskWeb.Models;
using TaskWeb.ViewModel;
namespace TaskWeb.Controllers
{
    public class TaskModelController : Controller
    {
        // GET: TaskModel
        public ActionResult Index()
        {
            TaskClient TC = new TaskClient();
            ViewBag.listTasks = TC.FindAll();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            TaskViewModel viewModel = new TaskViewModel();
            return View("Create", viewModel);
        }
        [HttpPost]
        public ActionResult Create(TaskModel tm)
        {
            TaskClient TC = new TaskClient();
            TC.Create(tm);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TaskClient TC = new TaskClient();
            TC.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TaskClient TC = new TaskClient();
            TaskViewModel tvm = new TaskViewModel();
            tvm.Task = TC.FindTask(id);
            return View("Edit", tvm);
        }
        [HttpPost]
        public ActionResult Edit(TaskViewModel tvm)
        {
            TaskClient TC = new TaskClient();
            TC.Edit(tvm.Task);
            return RedirectToAction("Index");
        }
    }
}