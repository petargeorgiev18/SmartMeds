package org.smartmeds.services;

import jakarta.enterprise.context.ApplicationScoped;
import jakarta.inject.Inject;
import org.smartmeds.models.entities.Hospital;
import org.smartmeds.models.entities.Request;
import org.smartmeds.models.requests.CreateRequest;
import org.smartmeds.repositories.HospitalRepository;
import org.smartmeds.repositories.RequestRepository;

import java.util.List;

@ApplicationScoped
public class RequestService {
    @Inject
    RequestRepository repo;

    @Inject
    HospitalRepository hospitalRepo;

    public Request create(CreateRequest data){
        Hospital from = hospitalRepo.findById(data.from);
        Hospital to = hospitalRepo.findById(data.to);
        if(from == null && to == null)
            throw new IllegalArgumentException("Invalid hospital data");
        Request request = data.toRequest();
        request.setFrom(from);
        request.setTo(to);
        repo.persist(request);
        return request;
    }

    public Request getById(Long id) {
        return repo.findById(id);
    }

    public List<Request> getAll() {
        return repo.listAll();
    }

    public void remove(Long id) {
        repo.deleteById(id);
    }

    public Request updateStatus(Request request, String status) {
        request.setStatus(status);
        repo.persist(request);
        return request;
    }

    public List<Request> getAllToHospital(Long id) {
        return repo.getAllToHospital(id);
    }

    public List<Request> getAllFromHospital(Long id) {
        return repo.getAllFromHospital(id);
    }

    public List<Request> getAllAboutHospital(Long id) {
        return repo.getAllAboutHospital(id);
    }
}
