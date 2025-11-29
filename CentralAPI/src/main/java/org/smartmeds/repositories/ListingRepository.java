package org.smartmeds.repositories;

import io.quarkus.hibernate.orm.panache.PanacheEntity;
import io.quarkus.hibernate.orm.panache.PanacheRepository;
import org.smartmeds.models.entities.Listing;

public class ListingRepository implements PanacheRepository<Listing> {

}
