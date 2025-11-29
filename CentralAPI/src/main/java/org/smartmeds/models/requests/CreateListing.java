package org.smartmeds.models.requests;

import io.smallrye.common.constraint.NotNull;
import jakarta.persistence.Column;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.Positive;
import org.smartmeds.models.entities.Listing;

import java.time.LocalDate;

public class CreateListing {
    @NotNull
    @NotEmpty
    @Positive
    Double price;

    @NotNull
    @NotEmpty
    LocalDate expiration;

    @NotNull
    @NotEmpty
    @Column(unique = true)
    Long MedicineFK;

    public Listing toListing() {
        Listing res = new Listing();
        res.setPrice(price);
        res.setExpiration(expiration);
        res.setMedicineFK(MedicineFK);

        return res;
    }
}
