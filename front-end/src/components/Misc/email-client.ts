import ClientSendingBlue, { EmailUser } from 'sendinblue-simple-client';

const mySecretApiKey = process.env.API_KEY;
const name =  process.env.DEFAULT_SENDER_NAME;
const email = process.env.DEFAULT_SEDNER_EMAIL;

const sendEmail = async (destinationEmail: string, destinationName: string = 'Felhasználó', amount: number, fromUser: string, adminTransaction = false) => {
    if(mySecretApiKey && name && email) {
        const emailClient: ClientSendingBlue = new ClientSendingBlue(
            mySecretApiKey
        );

        const sender: EmailUser = {
            name: name,
            email: email,
        };

        const destination: EmailUser = {
            name: destinationName,
            email: destinationEmail,
        };

        let templateNumber = 3;
        if(adminTransaction) templateNumber = 4;
        const content = await emailClient.templatesProvider(templateNumber);
        if (content) {
            try {
                const response = await emailClient.sendEmail({
                    sender: sender,
                    to: [destination],
                    subject: templateNumber === 3 ? 'Tranzakció került jóváírásra' : 'Jóváírás történt a számládra egy admin által',
                    templateId: templateNumber,
                    content: content,
                    contentParams: {
                        email: destinationEmail,
                        TRNSACTIONAMOUNT: amount,
                        TRANSACTIONUSER: fromUser,
                    },
                });
            } catch (error) {
                console.log(error);
            }
        }
    }
}


export default sendEmail;