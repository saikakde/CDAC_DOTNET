package com.blogs.controller;
//package com.example.railway;

import java.util.List;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.blogs.entities.Category;
import com.blogs.entities.Railway;
import com.blogs.service.RailwayService;

@RestController
@RequestMapping("/api/railways")
public class RailwayController {

    @Autowired
    private RailwayService railwayService;

    @PostMapping
    public ResponseEntity<Railway> addRailway(@Valid @RequestBody Railway railway) {
        if (railway.getStartTime().isAfter(railway.getEndTime())) {
            return ResponseEntity.badRequest().build();
        }
        Railway createdRailway = railwayService.addRailway(railway);
        return new ResponseEntity<>(createdRailway, HttpStatus.CREATED);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteRailway(@PathVariable Long id) {
        if (!railwayService.getRailwayById(id).isPresent()) {
            return ResponseEntity.notFound().build();
        }
        railwayService.deleteRailway(id);
        return ResponseEntity.noContent().build();
    }

    @GetMapping
    public ResponseEntity<List<Railway>> getRailwaysByCategory(@RequestParam Category category) {
        List<Railway> railways = railwayService.getRailwaysByCategory(category);
        if (railways.isEmpty()) {
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok(railways);
    }
    
    @GetMapping("/sortedByName")
    public ResponseEntity<List<Railway>> getAllRailwaysSortedByName() {
        List<Railway> railways = railwayService.getAllRailwaysSortedByName();
        return ResponseEntity.ok(railways);
    }
}

