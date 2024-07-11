package com.blogs.entities;

import java.time.LocalDateTime;
import java.time.LocalTime;

//package com.example.railway;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;

import com.fasterxml.jackson.annotation.JsonFormat;

@Entity
public class Railway {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "Name is mandatory")
    private String name;

    @Enumerated(EnumType.STRING)
    @NotNull(message = "Category is mandatory")
    private Category category;

//    @JsonFormat(pattern = "HH:mm:ss")
//    @NotNull(message = "Start time is mandatory")
//    private LocalDateTime startTime;
//
//    @JsonFormat(pattern = "HH:mm:ss")
//    @NotNull(message = "End time is mandatory")
//    private LocalDateTime endTime;
    @NotNull(message = "Start time is mandatory")
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "HH:mm:ss")
    private LocalTime startTime;

    @NotNull(message = "End time is mandatory")
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "HH:mm:ss")
    private LocalTime endTime;
    @NotBlank(message = "Source is mandatory")
    private String source;

    @NotBlank(message = "Destination is mandatory")
    private String destination;

    @NotBlank(message = "Station code is mandatory")
    private String stationCode;

    @NotNull(message = "Distance is mandatory")
    private Double distance;

    @NotBlank(message = "Frequency is mandatory")
    private String frequency;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Category getCategory() {
		return category;
	}

	public void setCategory(Category category) {
		this.category = category;
	}

//	public LocalDateTime getStartTime() {
//		return startTime;
//	}
//
//	public void setStartTime(LocalDateTime startTime) {
//		this.startTime = startTime;
//	}
//
//	public LocalDateTime getEndTime() {
//		return endTime;
//	}
//
//	public void setEndTime(LocalDateTime endTime) {
//		this.endTime = endTime;
//	}
	
	

	public String getSource() {
		return source;
	}

	public LocalTime getStartTime() {
		return startTime;
	}

	public void setStartTime(LocalTime startTime) {
		this.startTime = startTime;
	}

	public LocalTime getEndTime() {
		return endTime;
	}

	public void setEndTime(LocalTime endTime) {
		this.endTime = endTime;
	}

	public void setSource(String source) {
		this.source = source;
	}

	public String getDestination() {
		return destination;
	}

	public void setDestination(String destination) {
		this.destination = destination;
	}

	public String getStationCode() {
		return stationCode;
	}

	public void setStationCode(String stationCode) {
		this.stationCode = stationCode;
	}

	public Double getDistance() {
		return distance;
	}

	public void setDistance(Double distance) {
		this.distance = distance;
	}

	public String getFrequency() {
		return frequency;
	}

	public void setFrequency(String frequency) {
		this.frequency = frequency;
	}

	
    // Getters and Setters
    
}
