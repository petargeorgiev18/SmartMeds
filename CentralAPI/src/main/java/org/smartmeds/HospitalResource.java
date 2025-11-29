package org.smartmeds;

import jakarta.inject.Inject;
import jakarta.transaction.Transactional;
import jakarta.validation.Valid;
import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import org.smartmeds.models.entities.Hospital;
import org.smartmeds.models.requests.CreateHospital;
import org.smartmeds.services.HospitalService;

@Path("/hospitals")
public class HospitalResource {

    @Inject
    HospitalService hospitalService;

    @Path("/register")
    @POST
    @Transactional
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Response createHospital(@Valid CreateHospital data) {
        try{
            hospitalService.createHospital(data);
            return Response.ok().entity(data).build();
        }catch(Exception e) {
            return Response.status(Response.Status.INTERNAL_SERVER_ERROR).entity(e.getMessage()).build();
        }
    }

    @GET
    @Path("/get/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getHospital(@PathParam("id") Long id) {
        try{
            Hospital h = hospitalService.getById(id);
            if(h == null)
                return Response.noContent().build();
            return Response.ok(h).build();
        }catch (Exception e){
            return Response.serverError().build();
        }
    }
}
