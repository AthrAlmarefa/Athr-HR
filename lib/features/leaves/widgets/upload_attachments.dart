import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_button.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/data/implementation/offline_data_source_impl.dart';
import 'package:athr_hr/data/implementation/offline_file_helper.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class UploadAttachments extends StatefulWidget {
   const UploadAttachments({super.key});

   @override
   State<UploadAttachments> createState() => _UploadAttachmentsState();
 }

 class _UploadAttachmentsState extends State<UploadAttachments> {
   final fileDataSource = OfflineDataSourceImpl();


   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.attachments),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 6.h),
         SizedBox(
           width: 398.w,
           height: 64.h,
           child: CustomTextFormField(
             readOnly: true,
             showCursor: false,
             prefix: Row(
               children: [
                 Image.asset(
                   Assets.imagesPdffile,
                   width: 24.w,
                   height: 24.h,
                   fit: BoxFit.contain,),
                 SizedBox(width: 12.w,),
                 Text(context.translate(LangKeys.medicalConsultation),style: MyFonts.semiBold600_18.copyWith(
                   color: MyColors.black,)),
               ],
             ),
             suffix: GestureDetector(
               onTap: () async {
                 final savedPath = await fileDataSource.getCachedFilePath();
                 if (savedPath != null) {
                   await downloadCachedFile(savedPath);
                 }
               },
               child: Image.asset(
                 Assets.imagesDownloadpdf,
                 width: 24.w,
                 height: 24.h,
                 fit: BoxFit.contain,
               ),
             ),
           ),
         ),
         SizedBox(height: 20.h,),
         InkWell(
           onTap: () async {
             final file = await pickCustomFile();
             if (file != null) {
               await fileDataSource.cacheFile(file);
               print("File cached successfully!");
             }
           },
           child: Image.asset(Assets.imagesAttachmentsbutton,
             width: 398.w,
             height: 58.h,
             fit: BoxFit.fill,),
         ),
         SizedBox(height: 48.h,),
         SizedBox(
             width: 400.w,
             height: 58.h,
             child: CustomButton(txt: context.translate(LangKeys.submitRequest), onPressed: (){})),
       ],
     );
   }
 }
