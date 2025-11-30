package org.smartmeds.repositories;

import io.quarkus.hibernate.orm.panache.PanacheRepository;
import jakarta.enterprise.context.ApplicationScoped;
import org.smartmeds.models.entities.Request;

import java.util.List;

@ApplicationScoped
public class RequestRepository implements PanacheRepository<Request> {
    public List<Request> getAllToHospital(Long id) {
        return find("to.id", id).list();
    }

    public List<Request> getAllFromHospital(Long id) {
        return find("from.id", id).list();
    }

    public List<Request> getAllAboutHospital(Long id) {
        return find("to.id = ?1 OR from.id = ?1", id).list();
    }

    public List<Request> getAllAboutHospitalByStatus(Long id, String status) {
        return find("to.id = ?1 AND status = ?2", id, status).list();
    }
}
