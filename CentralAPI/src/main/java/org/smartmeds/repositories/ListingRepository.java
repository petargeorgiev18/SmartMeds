package org.smartmeds.repositories;

import io.quarkus.hibernate.orm.panache.PanacheEntity;
import io.quarkus.hibernate.orm.panache.PanacheRepository;
import jakarta.enterprise.context.ApplicationScoped;
import org.smartmeds.models.entities.Listing;

import java.util.List;

@ApplicationScoped
public class ListingRepository implements PanacheRepository<Listing> {
    public List<Listing> findAllByHospitalId(Long hospitalId){
        return list("hospital.id", hospitalId);
    }

    public List<Listing> findAllNotByHospitalId(Long hospitalId) {
        return list("hospital.id != ?1", hospitalId);
    }
}
