package org.smartmeds.models.requests;

import io.smallrye.common.constraint.NotNull;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.Size;
import org.jspecify.annotations.NonNull;
import org.smartmeds.models.entities.Hospital;

public class CreateHospital {
    @NotNull
    @NotEmpty
    @Size(min = 1, max = 50)
    public String name;

    @NotNull
    @NotEmpty
    @Size(min = 1, max = 100)
    public String city;

    @NotNull
    @NotEmpty
    public String address;

    public Hospital toHopital() {
        Hospital hospital = new Hospital();
        hospital.name = name;
        hospital.city = city;
        hospital.address = address;
        return hospital;
    }
}
