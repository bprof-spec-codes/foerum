const SibApiV3Sdk = require('sib-api-v3-sdk');
let defaultClient = SibApiV3Sdk.ApiClient.instance;

let apiKey = defaultClient.authentications['api-key'];
apiKey.apiKey = process.env.API_KEY;
let apiInstance = new SibApiV3Sdk.TransactionalEmailsApi();
let sendSmtpEmail = new SibApiV3Sdk.SendSmtpEmail();

const sendEmailV2 = async (destinationEmail: string, destinationName: string = 'Felhasználó', amount: number, fromUser: string, adminTransaction = false) => {
    if(process.env.DEFAULT_SENDER_NAME && process.env.DEFAULT_SEDNER_EMAIL) {
        let templateNumber = 3;
        if(adminTransaction) templateNumber = 4;
        sendSmtpEmail.subject = templateNumber === 3 ? 'Tranzakció került jóváírásra' : 'Jóváírás történt a számládra egy admin által';
        sendSmtpEmail.templateId = templateNumber;
        sendSmtpEmail.sender = {"name":process.env.DEFAULT_SENDER_NAME,"email":process.env.DEFAULT_SEDNER_EMAIL};
        sendSmtpEmail.to = [{"email":destinationEmail,"name":destinationName}];
        sendSmtpEmail.params =                      {
            "email": destinationEmail,
                "TRNSACTIONAMOUNT": amount,
                "TRANSACTIONUSER": fromUser,
        }

        apiInstance.sendTransacEmail(sendSmtpEmail).then();
    }

}

export default sendEmailV2;