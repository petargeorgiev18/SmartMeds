package org.smartmeds.services;

import jakarta.enterprise.context.ApplicationScoped;
import jakarta.inject.Inject;
import org.smartmeds.models.entities.Hospital;
import org.smartmeds.models.entities.Request;
import org.smartmeds.models.requests.CreateRequest;
import org.smartmeds.repositories.HospitalRepository;
import org.smartmeds.repositories.RequestRepository;

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
}
