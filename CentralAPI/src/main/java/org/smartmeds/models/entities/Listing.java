package org.smartmeds.models.entities;

import io.quarkus.hibernate.orm.panache.PanacheEntityBase;
import io.smallrye.common.constraint.NotNull;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.Positive;
import org.hibernate.validator.constraints.UniqueElements;

import java.time.LocalDate;

@Entity
public class Listing extends PanacheEntityBase {
    @Id
    @GeneratedValue
    public Long id;

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

    @ManyToOne
    Hospital hospital;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public @NotEmpty @Positive Double getPrice() {
        return price;
    }

    public void setPrice(@NotEmpty @Positive Double price) {
        this.price = price;
    }

    public @NotEmpty LocalDate getExpiration() {
        return expiration;
    }

    public void setExpiration(@NotEmpty LocalDate expiration) {
        this.expiration = expiration;
    }

    public @NotEmpty Long getMedicineFK() {
        return MedicineFK;
    }

    public void setMedicineFK(@NotEmpty Long medicineFK) {
        MedicineFK = medicineFK;
    }

    public Hospital getHospital() {
        return hospital;
    }

    public void setHospital(Hospital hospital) {
        this.hospital = hospital;
    }
}
