// backend/server.js

const express = require('express');
const bodyParser = require('body-parser');
const mongoose = require('mongoose');
const Curriculum = require('./curriculumModel');

const app = express();
const port = 3000;

// Connect to MongoDB
mongoose.connect('mongodb://localhost/ar_curriculum', { useNewUrlParser: true, useUnifiedTopology: true })
    .then(() => console.log('Connected to MongoDB'))
    .catch(error => console.error('Failed to connect to MongoDB:', error));

// Body parser middleware
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

// API endpoint for submitting curriculum data
app.post('/api/curriculum', async (req, res) => {
    try {
        const { title, description, file } = req.body;
        const curriculum = new Curriculum({
            title,
            description,
            file
        });
        await curriculum.save();
        res.status(201).json({ message: 'Curriculum created successfully' });
    } catch (error) {
        console.error(error);
        res.status(500).json({ message: 'Server error' });
    }
});

// Add endpoints for updating and deleting curriculum data
app.put('/api/curriculum/:id', async (req, res) => {
    // Update curriculum data
});

app.delete('/api/curriculum/:id', async (req, res) => {
    // Delete curriculum data
});

// Implement pagination for fetching curriculum data
app.get('/api/curriculum', async (req, res) => {
    const { page = 1, limit = 10 } = req.query;
    try {
        const curriculums = await Curriculum.find()
            .limit(limit * 1)
            .skip((page - 1) * limit)
            .exec();
        const count = await Curriculum.countDocuments();
        res.json({
            curriculums,
            totalPages: Math.ceil(count / limit),
            currentPage: page
        });
    } catch (error) {
        console.error('Error fetching curriculum data:', error);
        res.status(500).json({ message: 'Server error' });
    }
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
