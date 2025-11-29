package org.smartmeds;

import jakarta.inject.Inject;
import jakarta.transaction.Transactional;
import jakarta.validation.Valid;
import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import org.smartmeds.models.entities.Listing;
import org.smartmeds.models.requests.CreateListing;
import org.smartmeds.services.ListingService;

import java.util.Map;

@Path("/listings")
public class ListingsResource {

    @Inject
    ListingService service;

    @POST
    @Path("/add-listing")
    @Transactional
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Response createListing(@Valid CreateListing data, Long hospitalId){
        try{
            Listing listing = service.createListing(data, hospitalId);
            return Response.ok().entity(listing).build();
        }catch (Exception ex){
            if(ex.getMessage() != null && ex.getMessage().equals("Not found"))
                return Response.status(404).entity(Map.of("error", "Hospital Not Found")).build();

            return Response.serverError().build();
        }
    }

}
