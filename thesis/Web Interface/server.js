// backend/server.js

const express = require('express');
const multer = require('multer'); // Middleware for handling file uploads
const fs = require('fs');
const path = require('path');

const app = express();
const port = 3000;

// Set up multer to handle file uploads
const upload = multer({ dest: 'uploads/' }); // Destination directory for uploaded files

// Middleware to serve static files (optional)
app.use(express.static('public'));

// Route for handling file uploads
app.post('/api/uploadScene', upload.single('sceneFile'), (req, res) => {
    try {
        // Get the uploaded file from req.file
        const sceneFile = req.file;

        if (!sceneFile) {
            return res.status(400).json({ message: 'No file uploaded' });
        }

        // Save the uploaded file to a directory or database
        const uploadedFilePath = path.join(__dirname, 'uploads', sceneFile.originalname);
        fs.renameSync(sceneFile.path, uploadedFilePath);

        // Trigger an update in the Unity application or process the file as needed

        // Send a response indicating success
        res.status(200).json({ message: 'Scene uploaded successfully', filePath: uploadedFilePath });
    } catch (error) {
        console.error('Error uploading scene:', error);
        res.status(500).json({ message: 'Server error' });
    }
});

// Start the server
app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
