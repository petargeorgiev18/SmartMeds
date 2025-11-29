package org.smartmeds.services;

import jakarta.enterprise.context.ApplicationScoped;
import jakarta.inject.Inject;
import org.smartmeds.models.entities.Hospital;
import org.smartmeds.models.entities.Listing;
import org.smartmeds.models.requests.CreateListing;
import org.smartmeds.repositories.HospitalRepository;
import org.smartmeds.repositories.ListingRepository;

import java.util.List;
import java.util.Optional;

@ApplicationScoped
public class ListingService {

    @Inject
    ListingRepository repo;

    @Inject
    HospitalRepository hospitalRepo;

    public Listing createListing(CreateListing data, Long hospitalId){
        Optional<Hospital> hospital = hospitalRepo.findByIdOptional(hospitalId);
        if(hospital.isEmpty())
            throw new RuntimeException("Not found");

        Listing listing = data.toListing();
        listing.setHospital(hospital.get());
        repo.persist(listing);
        return listing;
    }

    public List<Listing> getAll() {
        return repo.listAll();
    }

    public List<Listing> getListingsByHospital(Long hospitalId) {
        List<Listing> res = repo.findAllByHospitalId(hospitalId);
        System.out.println(res);
        return res;
    }

    public Listing getById(Long id) {
        return repo.findById(id);
    }
}
