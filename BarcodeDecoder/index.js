import express from "express";
import multer from "multer";
import Tesseract from "tesseract.js";

const app = express();
app.use(express.json({ limit: "10mb" })); // allow large JSON

// Health check
app.get("/health", (req, res) => {
  res.json({ status: "ok" });
});

// Decode endpoint
/*
POST /decode
Content-Type: multipart/form-data
Body: image=<image.png> 
*/
app.post("/decode", async (req, res) => {
  try {
    const { imageUrl } = req.body;
    if (!imageUrl) return res.status(400).json({ error: "No image URL provided" });

    const { data: { text } } = await Tesseract.recognize(
      imageUrl, // Pass the URL directly
      "eng",
      { logger: m => console.log(m) } // optional progress logs
    );

    // Extract digits (barcode)
    const barcode = text.match(/\d+/g)?.join("") || null;
    
    const lookupURL =
      "https://api.upcitemdb.com/prod/trial/lookup?upc=" + barcode;

    const resp = await fetch(lookupURL, {
      method: "GET",
    });

    if (!resp.ok) {
      throw new Error("Failed to fetch product data");
    }

    const productData = await resp.json();

    res.json({
      success: true,
      title: productData?.items?.[0]?.title || "Unknown Product",
    });
  } catch (err) {
    res.json({
      success: false,
      error: err?.message ?? "Decoding failed",
    });
  }
});

// Start server
const port = process.env.PORT || 3600;
app.listen(port, () => console.log(`Barcode microservice running on port ${port}`));


/*
* Sample response from UPCItemDB API
{
  "code": "OK",
  "total": 1,
  "offset": 0,
  "items": [
    {
      "ean": "0885909950805",
      "title": "Apple iPhone 6, Space Gray, 64 GB (T-Mobile)",
      "upc": "885909950805",
      "gtin": "string",
      "asin": "B00NQGOZV0",
      "description": "iPhone 6 isn't just bigger - it's better...",
      "brand": "Apple",
      "model": "MG5A2LL/A",
      "dimension": "string",
      "weight": "string",
      "category": "Electronics > Communications > Telephony > Mobile Phones > Unlocked Mobile Phones",
      "currency": "string",
      "lowest_recorded_price": 3.79,
      "highest_recorded_price": 8500,
      "images": [
        "http://img1.r10.io/PIC/112231913/0/1/250/112231913.jpg"
      ],
      "offers": [
        {
          "merchant": "Newegg.com",
          "domain": "newegg.com",
          "title": "Apple iPhone 6 64GB T-Mobile Space Gray MG5A2LL/A",
          "currency": "string",
          "list_price": 0,
          "price": 1200,
          "shipping": "Free Shipping",
          "condition": "New",
          "availability": "Out of Stock",
          "link": "https://www.upcitemdb.com/norob/alink/?id=v2p2...",
          "updated_t": 1479243029
        }
      ]
    }
  ]
}
*/