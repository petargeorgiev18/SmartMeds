package org.smartmeds.models.requests;

import io.smallrye.common.constraint.NotNull;
import jakarta.persistence.ManyToOne;
import jakarta.validation.constraints.Positive;
import org.smartmeds.models.entities.Hospital;
import org.smartmeds.models.entities.Request;

import java.time.LocalDate;

public class CreateRequest {
    @NotNull
    public Long from;

    @NotNull
    public Long to;

    @NotNull
    @Positive
    public Integer amount;

    @NotNull
    public Long medicineFK;

    @NotNull
    public LocalDate expirationDate;

    public Request toRequest(){
        return new Request(amount, medicineFK, expirationDate, LocalDate.now(), "PENDING");
    }
}
