# Main decisions taken in the test

I have used **Unity 2021.1.0f1** because I was finishing a project using that same version. In order to be able to use Shadergraph and save myself some time during the shading process (as Shadergraph exports to HLSL), the entire project is done by using Unity’s **Universal Renderer Pipeline**, with every single visible string being driven by TextMeshPro.

As the center of the test is the anti-stress ball product, I’ve decided to focus the entire app around it. **_Every ball is a Scriptable Object_** with a name, a color, and its size possibilities. On startup, the app reads every single sphere stored in the Resources/Spheres folder, parses them into a button format, and puts them into a list for the user to choose.
If there’s a need for new kinds of balls, everything an operator has to do is to create a new one via Assets / Create / Balls and store it in the right folder. The item can be configured visually without touching a line of code.

On clicking a sphere button, its size and color are represented on the main sphere at the center of the screen, and its possible sizes are loaded, with default values at the middle between minimum and maximum size. However, if the user selects the black ball, the radius will be fixed at 5, with no possible changes.

I’ve also decided against using exact scaling for showing ball size. For this case, so long as the scale changes are properly conveyed to the user, there was no need to make balls too big or too small, as they’ll just be awkward to see.

The entire UI uses simple, Shadergraph-based materials and TextMeshPro as its text engine in order to ensure compatibility and scalability. This time, I’ve relied heavily on noise manipulation for shading as it brings good results quickly without having to use external assets.

Since design isn’t considered, I haven’t wasted any time beyond some very basic aesthetic configuration and the inclusion of a Unity Store Skybox. I’ve also refused to use any vertex manipulating via shader for a quick test, as I don’t know the hardware that may run this test and therefore didn’t want to risk a bad user experience.

