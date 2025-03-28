# Stepup auth using Angular .NET 

This project demonstrates Step Up Authentication Challenge ([RFC 9470](https://datatracker.ietf.org/doc/rfc9470/)) in a minimal Angular frontend interacting with a custom resource server written in .NET. Both frontend and API projects are minimal and are for demonstration purposes only.

This project is referenced in [Step up your authentication game](https://stepup-auth-game.alisaduncan.dev/) talk.

## Getting going

Clone the repo. You may want to fork it first so you can track changes in GitHub.

Install dependencies by running `npm ci`.

Open a terminal for the frontend and backend code directories. Start the frontend by running `npm start`. This starts the frontend app on port 4200.

Start the backend by running `dotnet run`. This starts the API on port 5043. Update the `API` path defined in `frontend/src/app/hero.service.ts` if the API runs on a different port.

## See the completed project

Check out the `completed` branch to see the final project.

---

Created by Alisa Duncan 2025

Author not responsible for production use or ongoing maintenance. Reach out to `dev-advocacy@okta.com`, [@alisaduncan.dev](https://bsky.app/profile/alisaduncan.dev) on Bluesky, or [@jalisaduncan](https://www.linkedin.com/in/jalisaduncan) on LinkedIn.

## License

Apache 2.0, see [LICENSE](LICENSE).