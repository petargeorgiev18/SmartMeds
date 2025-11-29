package org.smartmeds;

import io.smallrye.common.constraint.NotNull;
import jakarta.inject.Inject;
import jakarta.transaction.Transactional;
import jakarta.validation.Valid;
import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import org.smartmeds.models.entities.Listing;
import org.smartmeds.models.requests.CreateListing;
import org.smartmeds.services.ListingService;

import java.util.List;
import java.util.Map;

@Path("/listings")
public class ListingsResource {

    @Inject
    ListingService service;

    @POST
    @Path("/create")
    @Transactional
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Response createListing(@Valid CreateListing data, @QueryParam("hospitalId") Long hospitalId){
        try{
            Listing listing = service.createListing(data, hospitalId);
            return Response.ok().entity(listing).build();
        }catch (Exception ex){
            if(ex.getMessage() != null && ex.getMessage().equals("Not found"))
                return Response.status(404).entity(Map.of("error", "Hospital Not Found")).build();

            return Response.serverError().build();
        }
    }

    @GET
    @Path("/get-all")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getAllListings(){
        try{
            List<Listing> listings = service.getAll();
            return Response.ok().entity(listings).build();
        }catch (Exception ex){
            return Response.serverError().build();
        }
    }

    @GET
    @Path("/get-by-hospital/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getAllByHospitalId(@PathParam("id") Long hospitalId){
        try{
            List<Listing> listings = service.getListingsByHospital(hospitalId);
            return Response.ok().entity(listings).build();
        }catch (Exception ex){
            return Response.serverError().build();
        }
    }

    @GET
    @Path("/get-not-by-hospital/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getAllNotByHospitalId(@PathParam("id") Long hospitalId){
        try{
            List<Listing> listings = service.getListingsNotByHospital(hospitalId);
            return Response.ok().entity(listings).build();
        }catch (Exception ex){
            return Response.serverError().build();
        }
    }

    @GET
    @Path("/get/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getListingById(@PathParam("id") Long id){
        try{
            Listing res = service.getById(id);
            if(res == null)
                return Response.noContent().build();
            return Response.ok().entity(res).build();
        }catch (Exception e){
            return Response.serverError().build();
        }
    }

    @DELETE
    @Path("/delete/{id}")
    @Transactional
    public Response deleteListingById(@PathParam("id") Long id){
        try{
            if(service.getById(id) == null)
                return Response.noContent().build();
            service.delete(id);
            return Response.ok().build();
        }catch (Exception ex){
            return Response.serverError().build();
        }
    }
}
