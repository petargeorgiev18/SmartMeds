package org.smartmeds.models.entities;

import io.quarkus.hibernate.orm.panache.PanacheEntity;
import io.smallrye.common.constraint.NotNull;
import jakarta.persistence.Entity;
import jakarta.persistence.ManyToOne;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.Positive;
import jakarta.validation.constraints.Size;

import java.time.LocalDate;

@Entity
public class Request extends PanacheEntity {
    @ManyToOne
    Hospital from;

    @ManyToOne
    Hospital to;

    @NotNull
    @Positive
    Integer amount;

    @NotNull
    Long medicineFK;

    @NotNull
    LocalDate expirationDate;

    @NotNull
    LocalDate postedAt;

    @NotNull
    @NotEmpty
    @Size(min = 5, max = 20)
    String status = "PENDING";

    public Request(){}

    public Request(Integer amount, Long medicineFK, LocalDate expirationDate, LocalDate postedAt, String status) {
        this.amount = amount;
        this.medicineFK = medicineFK;
        this.expirationDate = expirationDate;
        this.postedAt = postedAt;
    }

    public Hospital getFrom() {
        return from;
    }

    public void setFrom(Hospital from) {
        this.from = from;
    }

    public Hospital getTo() {
        return to;
    }

    public void setTo(Hospital to) {
        this.to = to;
    }

    public @Positive Integer getAmount() {
        return amount;
    }

    public void setAmount(@Positive Integer amount) {
        this.amount = amount;
    }

    public Long getMedicineFK() {
        return medicineFK;
    }

    public void setMedicineFK(Long medicineFK) {
        this.medicineFK = medicineFK;
    }

    public LocalDate getExpirationDate() {
        return expirationDate;
    }

    public void setExpirationDate(LocalDate expirationDate) {
        this.expirationDate = expirationDate;
    }

    public LocalDate getPostedAt() {
        return postedAt;
    }

    public void setPostedAt(LocalDate postedAt) {
        this.postedAt = postedAt;
    }

    public @NotEmpty @Size(min = 5, max = 20) String getStatus() {
        return status;
    }

    public void setStatus(@NotEmpty @Size(min = 5, max = 20) String status) {
        this.status = status;
    }
}
