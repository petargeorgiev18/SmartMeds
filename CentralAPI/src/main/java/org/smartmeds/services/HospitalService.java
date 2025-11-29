package org.smartmeds.services;

import jakarta.enterprise.context.ApplicationScoped;
import jakarta.inject.Inject;
import org.smartmeds.models.entities.Hospital;
import org.smartmeds.models.requests.CreateHospital;
import org.smartmeds.repositories.HospitalRepository;

@ApplicationScoped
public class HospitalService {
    @Inject
    HospitalRepository repo;

    public Hospital createHospital(CreateHospital data) {
        Hospital hospital = data.toHopital();
        repo.persist(hospital);
        return hospital;
    }
}
