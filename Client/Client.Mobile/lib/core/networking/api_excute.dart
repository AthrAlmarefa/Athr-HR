import 'dart:async';
import 'package:athr_hr/core/networking/common/api_result.dart';


Future<DataResult<T>> executeApi<T>(Future<T> Function() apiCall) async {
  try {
    var result = await apiCall.call();
    return Success(result);
  } on Exception catch (e) {
    return Fail(e);
  }
}