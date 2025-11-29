package org.smartmeds;

import jakarta.inject.Inject;
import jakarta.transaction.Transactional;
import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import org.smartmeds.models.entities.Request;
import org.smartmeds.models.requests.CreateRequest;
import org.smartmeds.services.RequestService;

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
}
