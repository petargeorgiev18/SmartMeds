package org.smartmeds;

import jakarta.inject.Inject;
import jakarta.transaction.Transactional;
import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import org.smartmeds.models.entities.Hospital;
import org.smartmeds.models.entities.Request;
import org.smartmeds.models.requests.CreateRequest;
import org.smartmeds.services.RequestService;

import java.util.List;

@Path("/requests")
public class RequestResource {

    @Inject
    RequestService service;

    @POST
    @Path("/create")
    @Transactional
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Response createRequest(CreateRequest data) {
        try{
            Request res = service.create(data);
            return Response.ok(res).build();
        }catch(Exception e){
            return Response.serverError().build();
        }
    }

    @GET
    @Path("/get/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getRequest(@PathParam("id") Long id) {
        try{
            Request r = service.getById(id);
            if(r == null)
                return Response.noContent().build();
            return Response.ok(r).build();
        }catch (Exception e){
            return Response.serverError().build();
        }
    }

    @GET
    @Path("/get-all")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getAllRequests() {
        try{
            List<Request> res = service.getAll();
            return Response.ok().entity(res).build();
        }catch (Exception e){
            return Response.serverError().build();
        }
    }

    @DELETE
    @Path("/delete/{id}")
    @Transactional
    public Response deleteRequest(@PathParam("id") Long id) {
        try {
            if(service.getById(id) == null)
                return Response.noContent().build();
            service.remove(id);
            return Response.ok().build();
        }catch (Exception e){
            return Response.serverError().build();
        }
    }

    @PUT
    @Path("/update-status/{id}")
    @Transactional
    @Produces(MediaType.APPLICATION_JSON)
    public Response updateRequestStatus(@PathParam("id") Long id, @QueryParam("status") String status) {
        try{
            Request request = service.getById(id);
            if(request == null)
                return Response.status(404).build();
            request = service.updateStatus(request, status);
            return Response.ok(request).build();
        }catch (Exception e){
            return Response.serverError().build();
        }
    }
}
