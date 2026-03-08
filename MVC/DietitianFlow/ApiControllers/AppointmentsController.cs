using DietitianFlow.Services;
using DietitianFlowManuelMethods;
using System.Web.Http;

namespace DietitianFlow.ApiControllers
{
    [RoutePrefix("api/appointments")]
    public class AppointmentsApiController : ApiController
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsApiController()
        {
            _appointmentService = new AppointmentService();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var appointments = _appointmentService.GetAppointments();
            return Ok(appointments);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var appointment = _appointmentService.GetAppointment(id);

            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] uc_Appointments appointment)
        {
            if (appointment == null)
                return BadRequest("Appointment data is required.");

            _appointmentService.CreateAppointment(appointment);

            return Ok("Appointment created successfully.");
        }
    }
}