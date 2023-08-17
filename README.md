# SAMPL.ME
Implementation of my Splice "Software As A Service" clone.

## The Idea
Create the SoundCloud of samples where users can pay for their favourite artists samples.

## The stack
### Netcore API (SurrealASP)
This is the main backend for the website + app. It's using the SurrealASP package i wrote to build out
the actual backend services.
It handles the db behind the scenes and is basically an ORM by default. 

### Rust S3 Uploader
This is a simple service written in Rust to handle file uploads and media conversions.

### Rust SMTP API (Lettre)
This is mainly used for registration. I need to validate that users have an actual email associated with their
account.

### CLI
This is probably going to be needed for development. I need to be able to handle test cases, file uploads, mocks, etc..

### Svelte Website Frontend
This is the main website, will be used as client side interface + admin side. 
Users will be able to handle their profile, buy samples, handle payment options and so on..

### Tauri app
This could be a good idea if i want to implement a simple plugin to be able to access the samples one has bought.
Should be a simple filtered list + ability to buy new samples on the fly.
This is probably going to be the hardest part, since:
- It has to be on par with Splice
- It needs to be functional and make your life easy, not hard.
- It needs to sync with your profile
- Using Tauri and or Electron is going to be a massive pain in the ass.
- Must work on Mac and Windows

### SurrealDb
This is the Database for the project. Nothing special, just a simple instance of SurrealDb running on Fly.io

### WasabiS3
Storage bucket for the project

### Fly.Io
Hosting

### Stripe
Payment system using stripe, should handle most of the grunt work of handling payments. Needs to be coupled with API.
