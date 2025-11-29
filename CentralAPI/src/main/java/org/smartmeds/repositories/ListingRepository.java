package org.smartmeds.repositories;

import io.quarkus.hibernate.orm.panache.PanacheEntity;
import io.quarkus.hibernate.orm.panache.PanacheRepository;
import jakarta.enterprise.context.ApplicationScoped;
import org.smartmeds.models.entities.Listing;

@ApplicationScoped
public class ListingRepository implements PanacheRepository<Listing> {

}
