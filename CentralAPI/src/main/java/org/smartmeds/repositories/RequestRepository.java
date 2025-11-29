package org.smartmeds.repositories;

import io.quarkus.hibernate.orm.panache.PanacheRepository;
import jakarta.enterprise.context.ApplicationScoped;
import org.smartmeds.models.entities.Request;

@ApplicationScoped
public class RequestRepository implements PanacheRepository<Request> {
}
